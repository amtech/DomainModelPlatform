using Domain.Bll.Interface;
using Infrastructure.Common.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Bll
{
    /// <summary>领域模型业务基类</summary>
    public class BaseBll : IBll
    {
        private int moduleId;
        private RequestPackage request;
        private ResponsePackage response;

        public virtual int ModuleId
        {
            get
            {
                return moduleId;
            }
            set
            {
                moduleId = value;
            }
        }

        public RequestPackage Request
        {
            get
            {
                return request;    
            } 
            set
            {
                request = value;
            }
        }

        public ResponsePackage Response
        {
            get
            {
                return response;
            }
            set
            {
                response = value;
            }
        }

        public virtual void Add()
        {
             
        }

        public virtual void Delete()
        {
            
        }

        public virtual void Modify()
        {
             
        }

        public virtual void Query()
        {
            
        }
    }
}
