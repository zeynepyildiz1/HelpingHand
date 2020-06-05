﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HelpingHandProject.Core.Response
{
   
        public class BaseResponse<T> where T : class
        {
            public T Extra { get; set; }

            public bool Success { get; set; }

            public string ErrorMessage { get; set; }

            public BaseResponse(T extra)
            {
                this.Success = true;
                this.Extra = extra;
            }

            public BaseResponse(string errorMessage)
            {
                this.Success = false;
                this.ErrorMessage = errorMessage;
            }
        }
    }
