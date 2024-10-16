﻿using btl_backend.Dtos;
using btl_backend.Models;
using btl_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace btl_backend.Controllers;

[ApiController]
[Route("api/sv")]
public class SvController : ControllerBase
{
    private readonly UserService _userService;
    private readonly CodeJudgeService _codeJudgeService;

    public SvController(UserService userService, CodeJudgeService codeJudgeService)
    {
        _userService = userService;
        _codeJudgeService = codeJudgeService;
    }

    [HttpGet("problemset")]
    public async Task<IActionResult> GetProblemSet(int svId)
    {
        var problems = await _userService.GetProblemSetAsync(svId);

        return Ok(problems);
    }

    [HttpGet("problemset/class/{classId}")]
    public async Task<IActionResult> GetProblemSetByClass(int svId, int classId)
    {
        var problems = await _userService.GetProblemSetAsync(svId);

        return Ok(problems);
    }

    [HttpGet("problem/{problemId}")]
    public IActionResult GetProblem(int svId, int problemId)
    {
        var problem = _userService.GetProblem(svId, problemId);
        if (problem == null)
        {
            return Unauthorized();
        }
        return Ok(problem);
    }

    [HttpGet("allsubmissions")]
    public async Task<IActionResult> GetSubmissions(int svId)
    {
        var submissions = await _userService.GetUserSubmissionsAsync(svId);
        return Ok(submissions);
    }

    [HttpGet("submissions/problem/{problemId}")]
    public async Task<IActionResult> GetProblemSubmissions(int svId, int problemId)
    {
        var submissions = await _userService.GetProblemSubmissionsAsync(svId, problemId);
        return Ok(submissions);
    }

    [HttpPost("submit/problem/{problemId}")]
    public async Task<IActionResult> SubmitSolution(int svId, int problemId, SubmissionDto submission)
    {
        // Console.WriteLine(submission.Code);
        // Console.WriteLine((Language) submission.Language);
        var problem = _userService.GetProblem(svId, problemId);
        if (problem == null)
        {
            return Unauthorized();
        }

        var submissionResult = await _codeJudgeService.JudgeSubmissionAsync(svId, problemId, submission.Code, submission.Language);
        return Ok(new { Result = submissionResult, SubmittedCode = submission.Code });
    }
}