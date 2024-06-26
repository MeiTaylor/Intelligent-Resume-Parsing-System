﻿namespace resume.WebSentModel
{

    /// <summary>
    /// 上传简历时所需的信息
    /// </summary>
    public class JobInfoSentModel
    {
        public int UserId { get; set; }
        public string? JobName { get; set; }
        public string? JobDetails { get; set; }
        public List<string> JobKeywords { get; set; } // 岗位关键词
        public int MinimumWorkYears { get; set; }
        public string? MinimumEducationLevel { get; set; }
    }
}
