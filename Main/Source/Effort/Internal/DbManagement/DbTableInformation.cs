﻿#region License

// Copyright (c) 2011 Effort Team
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is 
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

#endregion

using System;
using System.Reflection;
using System.Collections.Generic;

namespace Effort.Internal.DbManagement
{
	internal class DbTableInformation
	{
        public DbTableInformation(string tableName, Type entityType, PropertyInfo[] primaryKeys, PropertyInfo identityField, PropertyInfo[] properties, object[] constraints, object primaryKeyInfo)
		{
            this.TableName = tableName;
			this.EntityType = entityType;
			this.PrimaryKeyFields = primaryKeys;
			this.IdentityField = identityField;
			this.Properties = properties;
            this.Constraints = constraints;
            this.PrimaryKeyInfo = primaryKeyInfo;
		}

        public string TableName { get; set; }

		public Type EntityType { get; private set; }

		public PropertyInfo[] PrimaryKeyFields { get; private set; }

		public PropertyInfo IdentityField { get; private set; }

		public PropertyInfo[] Properties { get; private set; }

        //NMemory.Constraints.IConstraint<TEntity> array
        public object[] Constraints { get; private set; }

        public object PrimaryKeyInfo { get; private set; }

	}
}
