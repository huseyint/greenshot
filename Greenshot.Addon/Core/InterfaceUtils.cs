﻿//  Greenshot - a free and open source screenshot tool
//  Copyright (C) 2007-2017 Thomas Braun, Jens Klingen, Robin Krom
// 
//  For more information see: http://getgreenshot.org/
//  The Greenshot project is hosted on GitHub: https://github.com/greenshot
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 1 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using Dapplo.Log;

#endregion

namespace Greenshot.Addon.Core
{
	/// <summary>
	///     Description of InterfaceUtils.
	/// </summary>
	public static class InterfaceUtils
	{
		private static readonly LogSource Log = new LogSource();

		public static IEnumerable<Type> GetSubclassesOf(Type implementingType, bool excludeSystemTypes)
		{
			var subClasses = from assembly in AppDomain.CurrentDomain.GetAssemblies()
				where !assembly.FullName.StartsWith("System") && !assembly.FullName.StartsWith("mscorlib") && !assembly.FullName.StartsWith("Microsoft")
				from type in assembly.GetTypes()
				where type.IsClass && !type.IsAbstract && implementingType.IsAssignableFrom(type)
				select type;
			return subClasses;
		}
	}
}