using System.Diagnostics;
using btl_backend.Data;
using btl_backend.Dtos;
using btl_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace btl_backend.Services;

// Services/CodeJudgeService.cs
public class CodeJudgeService
{
    private class CodeExecutor
    {
        public static string ExecuteCppCode(string submittedcode, string testcode)
        {
            var tempFile = Path.GetTempFileName() + ".cpp";
            var header = "#include <bits/stdc++.h>\nusing namespace std;";
            File.WriteAllText(tempFile,header + submittedcode + testcode);

            // Compile the C++ code
            var exeFile = Path.GetTempFileName() + ".exe";
            var e = ExecuteCode("g++", $"{tempFile} -o {exeFile}");

            if (!string.IsNullOrEmpty(e)) {
                return "Compile error:\n" + e;
            }

            // Execute the compiled C++ code
            return ExecuteCode(exeFile, "");
        }

        public static string ExecutePythonCode(string submittedcode, string testcode)
        {
            var tempFile = Path.GetTempFileName() + ".py";
            File.WriteAllText(tempFile, submittedcode + testcode);

            return ExecuteCode("python", tempFile);
        }

        public static string ExecuteJavaCode(string submittedcode, string testcode)
        {
            var tempFile = Path.GetTempFileName() + ".java";
            File.WriteAllText(tempFile, submittedcode + testcode);

            // Compile the Java code
            var e = ExecuteCode("javac", tempFile);

            if (!string.IsNullOrEmpty(e)) {
                return "Compile error:\n" + e;
            }

            // Execute the compiled Java code
            return ExecuteCode("java", "Main");
        }

        public static string ExecuteJavascriptCode(string submittedcode, string testcode)
        {
            var tempFile = Path.GetTempFileName() + ".js";
            File.WriteAllText(tempFile, submittedcode + testcode);

            return ExecuteCode("node", tempFile);
        }

        public static string ExecuteTypescriptCode(string submittedcode, string testcode)
        {
            var tempFile = Path.GetTempFileName() + ".ts";
            File.WriteAllText(tempFile, submittedcode + testcode);

            // Compile the Typescript code
            var e = ExecuteCode("tsc", tempFile);

            if (!string.IsNullOrEmpty(e)) {
                return "Compile error:\n" + e;
            }

            // Execute the compiled Typescript code
            return ExecuteCode("node", tempFile.Replace(".ts", ".js"));
        }

        private static string ExecuteCode(string command, string arguments)
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = command,
                    Arguments = arguments,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();

            var output = process.StandardOutput.ReadToEnd();
            var error = process.StandardError.ReadToEnd();

            process.WaitForExit();

            if (!string.IsNullOrEmpty(error))
            {
                return error;
            }
            return output;
        }
    }
    private readonly AppDbContext _context;

    public CodeJudgeService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<string> JudgeSubmissionAsync(int userId, int problemId, string submittedCode, int language)
    {
        var testCode = await _context.Problems
            .Where(p => p.ProblemId == problemId)
            .Select(p => p.TestCode)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        var result = language switch
        {
            (int)Language.Cpp => CodeExecutor.ExecuteCppCode(submittedCode, testCode?[language] ?? ""),
            (int)Language.Python => CodeExecutor.ExecutePythonCode(submittedCode, testCode?[language] ?? ""),
            (int)Language.Java => CodeExecutor.ExecuteJavaCode(submittedCode, testCode?[language] ?? ""),
            (int)Language.JavaScript => CodeExecutor.ExecuteJavascriptCode(submittedCode, testCode?[language] ?? ""),
            (int)Language.TypeScript => CodeExecutor.ExecuteTypescriptCode(submittedCode, testCode?[language] ?? ""),
            _ => "Not implemented language"
        };

        if (result == "Not implemented language")
        {
            return result;
        }

        var submission = new Submission()
        {
            ProblemId = problemId,
            UserId = userId,
            Code = submittedCode,
            ExecutionTime = 0,
            Language = language,
            Memory = 0,
            Result = result,
            Status = result[0] switch
            {
                'C' => (int) Statuses.CompilationError,
                'A' => (int) Statuses.Accepted,
                'W' => (int) Statuses.WrongAnswer,
                'T' => (int) Statuses.TimeLimitExceeded,
                'M' => (int) Statuses.MemoryLimitExceeded,
                'R' => (int) Statuses.RuntimeError,
                _ => (int) Statuses.NotImplemented,
            },
            SubmissionTime = DateTime.UtcNow,
        };

        await _context.Submissions.AddAsync(submission);
        await _context.SaveChangesAsync();

        return result;
    }
}