﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using resume.Others;
using resume.ResultModels;
using resume.Services;
using resume.WebSentModel;

namespace resume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly JobService _jobService;
        public JobController(JobService jobService)
        {
            _jobService = jobService;
        }
        /// <summary>
        /// 上传岗位，包括岗位名称，岗位详情，设置选项，最低工作年限，最低学历等。
        /// </summary>
        /// <param name="jobInfo"></param>
        /// <returns></returns>
        [HttpPost("uploadJobs")]
        public JobIdResultClass UploadJob(JobInfoSentModel jobInfo) {
            //将该Jobinfo存入数据库
            //并返回新的岗位ID
            var result = _jobService.UploadJob(jobInfo);
            return result;
        }

        /// <summary>
        /// 人岗匹配 ：获取某个岗位的人岗匹配结果，包括简历得分排序和人岗匹配原因。
        /// </summary>
        /// <param name="allId"></param>
        /// <returns></returns>
        [HttpPost("Match")]
        public JobMatchResultModelClass JobMatchResume(JobIdSentClass allId)
        {
            int userId=allId.UserId;
            int jobId = allId.JobId;

            //根据userID以及jobID 查数据库 该公司该岗位对应的所有简历
            var result = _jobService.JobMatchResume(userId, jobId);
            return result;
        }

        /// <summary>
        /// 返回该公司的所有的岗位的id以及信息
        /// </summary>
        /// <param name="webSentUserId"></param>
        /// <returns></returns>
        [HttpPost("allJobName")]
        public AllJobInfoResultClass forAllJobName(WebSentUserId webSentUserId)
        {
            int userId = webSentUserId.Id;
            //返回该公司的所上传的所有简历的名字以及简历ID
            var result = _jobService.forAllJobName(userId);
            return result;
        }

        [HttpPost("allJobNameOrdered")]
        public AllJobInfoResultClass forAllJobNameOrderedByCreationTime(WebSentUserId webSentUserId)
        {
            int userId = webSentUserId.Id;
            //返回该公司的所上传的所有简历的名字以及简历ID
            var result = _jobService.forAllJobNameOrderedByResumeCount(userId);
            return result;
        }

        [HttpPost("JobInfo")]
        public JobInfoSentModel GetJobInfo(WebSentUserId webSentUserId)
        {
            //这里就省略了，就不再新创建一个jobid了
            int userId = webSentUserId.Id;
            //返回该公司的所上传的所有简历的名字以及简历ID
            var result = _jobService.GetJobInfo(userId);
            return result;
        }

    }
}
