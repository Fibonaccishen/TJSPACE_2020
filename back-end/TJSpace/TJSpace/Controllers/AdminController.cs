﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TJSpace.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly DataDBContext dbContext;

        public AdminController(DataDBContext context)
        {
            dbContext = context;
        }

        //封禁用户
        [HttpPut]
        public ActionResult<string> SuspendUser([FromBody]string UserId)
        {
            var user = dbContext.Accounts.Where(u => u.UserId == UserId).ToList().FirstOrDefault();
            if(user==null)
            {
                return Ok(new
                {
                    status = false,
                    msg = "封禁用户失败，该用户不存在"
                });
            }
            user.State = 0;
            if (dbContext.SaveChanges() == 1)
            {
                return Ok(new
                {
                    status = true,
                    msg = "封禁用户成功"
                });
            }
            else
            {
                return Ok(new
                {
                    status = false,
                    msg = "封禁用户失败"
                });
            }
        }
    }
}
