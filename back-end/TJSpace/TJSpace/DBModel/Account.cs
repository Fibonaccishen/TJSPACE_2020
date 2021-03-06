﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MySql.Data.EntityFrameworkCore.DataAnnotations;
using Newtonsoft.Json;

namespace TJSpace.DBModel
{
    [MySqlCharset("utf8mb4")] //字符集
    [MySqlCollation("utf8mb4_general_ci")] //排序规则
    [Table("account", Schema = "tjspace")]

    public class Account
    {
        //邮箱
        [Key]
        [JsonProperty("email")]
        [Required]
        [Column("e_mail")]
        public string Email { get; set; }

        //密码
        [JsonProperty("password")]
        [Required]
        [Column("password")]
        [StringLength(maximumLength:20)]
        public string Password { get; set; }

        //状态
        [JsonProperty("state")]
        [Required]
        [Column("state", TypeName = "int(11)")]
        public int State { get; set; }

        //用户类型
        [JsonProperty("type")]
        [Required]
        [Column("type", TypeName = "int(11)")]
        public int Type { get; set; }

        //用户编号
        [JsonProperty("userid")]
        [Column("user_id")]
        [StringLength(maximumLength: 50)]
        public string UserId { get; set; }

 

    }
}
