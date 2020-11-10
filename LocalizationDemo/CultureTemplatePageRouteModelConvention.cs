﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace LocalizationDemo.RouteModelConventions
{
    public class CultureTemplatePageRouteModelConvention : IPageRouteModelConvention
    {
        public void Apply(PageRouteModel model)
        {
            var selectorCount = model.Selectors.Count;

            for (var i = 0; i < selectorCount; i++)
            {
                var selector = model.Selectors[i];

                model.Selectors.Add(new SelectorModel
                {
                    AttributeRouteModel = new AttributeRouteModel
                    {
                        Order = -1,
                        Template = AttributeRouteModel.CombineTemplates("{culture?}", selector.AttributeRouteModel.Template),
                    }
                });
            }
        }
    }
}
