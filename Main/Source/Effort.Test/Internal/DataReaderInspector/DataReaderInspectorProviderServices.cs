﻿// --------------------------------------------------------------------------------------------
// <copyright file="DataReaderInspectorProviderServices.cs" company="Effort Team">
//     Copyright (C) 2011-2014 Effort Team
//
//     Permission is hereby granted, free of charge, to any person obtaining a copy
//     of this software and associated documentation files (the "Software"), to deal
//     in the Software without restriction, including without limitation the rights
//     to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//     copies of the Software, and to permit persons to whom the Software is
//     furnished to do so, subject to the following conditions:
//
//     The above copyright notice and this permission notice shall be included in
//     all copies or substantial portions of the Software.
//
//     THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//     IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//     FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//     AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//     LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//     OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//     THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------

namespace Effort.Test.Internal.DataReaderInspector
{
    using System;
#if !EFOLD
    using System.Data.Entity.Core.Common;
    using System.Data.Entity.Core.Common.CommandTrees;
#else
    using System.Data.Common;
    using System.Data.Common.CommandTrees;
#endif
    using Effort.Provider;
    using Effort.Test.Internal.WrapperProviders;

    internal class DataReaderInspectorProviderServices : DbProviderServicesBase
    {
        public static readonly DataReaderInspectorProviderServices Instance =
            new DataReaderInspectorProviderServices();

        protected override string DefaultWrappedProviderName
        {
            get { return EffortProviderConfiguration.ProviderInvariantName; }
        }

        protected override string ProviderInvariantName
        {
            get { return DataReaderInspectorProviderConfiguration.ProviderInvariantName; }
        }

        public override DbCommandDefinitionWrapper CreateCommandDefinitionWrapper(DbCommandDefinition wrappedCommandDefinition, DbCommandTree commandTree)
        {
            return new DbCommandDefinitionWrapper(
                wrappedCommandDefinition,
                commandTree,
                (tree, definition) => new DataReaderInspectorCommand(tree, definition));
        }
    }
}
