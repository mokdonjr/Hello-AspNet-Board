using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// 반드시 추가
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

// Code First ORM Framework 이용

namespace HelloAspNetMvc.Models
{
    public class Post
    {
        [Key] // 'postNo' 컬럼을 primary key로 설정
        public int postNo { get; set; }
        public string name { get; set; }
        public string subject { get; set; }
        public string content { get; set; }
        public DateTime writeTime { get; set; }
        public int readCount { get; set; }
    }

    public class EFDbContext : DbContext
    {
        public EFDbContext()
            : base("name=EFDbContext") // Web.config 파일의 connection string을 참조
        {

        }
        public DbSet<Post> Posts { get; set; }
    }
}