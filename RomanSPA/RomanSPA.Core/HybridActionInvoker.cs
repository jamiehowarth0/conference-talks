﻿namespace RomanSPA {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Web.Mvc;
    using RomanSPA.Models;

    public class RomanActionInvoker : ControllerActionInvoker {
        
        protected override ActionResult InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary<string, object> parameters) {
            ActionResult result = null;
            var attribute = actionDescriptor.GetType().GetCustomAttribute<RomanActionAttribute>(false);

            if (attribute != null) {
                if (attribute.Factory != null) {
                    // result = new JsonResult() { Data = attribute.Factory.Execute(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                } else {
                    result = (ViewResult)base.InvokeActionMethod(controllerContext, actionDescriptor, parameters);
                }
            } else {
                result = (ViewResult)base.InvokeActionMethod(controllerContext, actionDescriptor, parameters);
            }
            return result;
        }
    }
}
