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
        public static string ExecutePythonCode(string submittedcode, string testcode)
        {
            string tempFile = Path.GetTempFileName() + ".py";
            File.WriteAllText(tempFile, submittedcode + testcode);

            return ExecuteCode("python", tempFile);
        }

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
        var result = "";
        if (language == (int) Language.Cpp)
        {
            result = CodeExecutor.ExecuteCppCode(submittedCode, testCode?[language] ?? "");
        }
        else if (language == (int)Language.Python)
        {
            result = CodeExecutor.ExecutePythonCode(submittedCode, testCode?[language] ?? "");
        }
        else
        {
            result = "Not implemented language";
        }

        // var submission = new Submission()
        // {
        //     ProblemId = problemId,
        //     UserId = userId,
        //     Code = submittedCode,
        //     ExecutionTime = 0,
        //     Language = language,
        //     Memory = 0,
        //     Status = result,
        //     SubmissionTime = DateTime.Now,
        // };
        //
        // await _context.Submissions.AddAsync(submission);
        // await _context.SaveChangesAsync();

        return result;
    }
}