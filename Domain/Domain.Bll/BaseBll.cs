using Domain.Bll.Interface;
using DMP.Infrastructure.Common.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Bll
{
    public class BaseBll : IBll
    {
        private int moduleId;
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
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public ResponsePackage Response
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public virtual void Add()
        {
            throw new NotImplementedException();
        }

        public virtual void Delete()
        {
            throw new NotImplementedException();
        }

        public virtual void Modify()
        {
            throw new NotImplementedException();
        }

        public virtual void Query()
        {
            throw new NotImplementedException();
        }
    }
}
