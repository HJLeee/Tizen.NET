﻿/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUILayout
{
    internal class AbsolutePivotTopStartPMargin : View, IExample
    {
        public AbsolutePivotTopStartPMargin()
        {
            Layout = new AbsoluteLayout();
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;
            BackgroundColor = Color.Gray;
            Margin = 100;

            var background = new View()
            {
                Layout = new AbsoluteLayout(),
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.DarkGray,
            };
            Add(background);

            var view = new View()
            {
                Layout = new AbsoluteLayout(),
                WidthSpecification = 100,
                HeightSpecification = 100,
                BackgroundColor = Color.Blue,
                PositionUsesPivotPoint = true,
                PivotPoint = new Position(0.0f, 0.0f),
                ParentOrigin = new Position(0.0f, 0.0f),
            };
            Add(view);
        }

        public void Activate()
        {
            Console.WriteLine($"@@@ this.GetType().Name={this.GetType().Name}, Activate()");

            var contentPage = new ContentPage()
            {
                AppBar = new AppBar() { Title = "PivotTopStart PMargin", BackgroundColor = Color.White },
                Content = this,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.LightGray,
            };
            Window.Default.GetDefaultNavigator().Push(contentPage);
        }
        public void Deactivate()
        {
            Console.WriteLine($"@@@ this.GetType().Name={this.GetType().Name}, Deactivate()");
            Window.Default.GetDefaultNavigator().Pop();
        }
    }
}
