﻿using System.ComponentModel;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;

namespace Xpand.Persistent.BaseImpl.JobScheduler {
    public class JobTypeClassInfoConverter : ClassInfoTypeConverter {
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context) {
            var typeInfo = XafTypesInfo.Instance.FindTypeInfo("Quartz.IJob");
            var typeInfos = ReflectionHelper.FindTypeDescendants(typeInfo).Where(info => !info.IsInterface&&!info.IsAbstract).Select(info => info.Type).ToList();
            return new StandardValuesCollection(typeInfos);
        }
    }
}