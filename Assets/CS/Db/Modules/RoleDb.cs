﻿using UnityEngine;
using System.Collections;
using Mono.Data.Sqlite;
using Newtonsoft.Json.Linq;

namespace Game {
	/// <summary>
	/// 角色相关数据模块
	/// </summary>
	public partial class DbManager {
		/// <summary>
		/// 添加新的角色数据
		/// </summary>
		/// <param name="roleId">Role identifier.</param>
		/// <param name="roleData">Role data.</param>
		/// <param name="state">State.</param>
		/// <param name="belongToRoleId">Belong to role identifier.</param>
		/// <param name="dateTime">Date time.</param>
		public void AddNewRole(string roleId, string roleData, int state, string belongToRoleId, string dateTime) {
			db = OpenDb();
			SqliteDataReader sqReader = db.ExecuteQuery("select RoleId from RolesTable where RoleId = '" + roleId + "'");
			if (!sqReader.HasRows) {
				db.ExecuteQuery("insert into RolesTable values('" + roleId + "', '" + roleData + "', " + state + ", '" + belongToRoleId + "', '" + dateTime + "');");
			}
			db.CloseSqlConnection();
		}

		/// <summary>
		/// 请求队伍信息面板数据
		/// </summary>
		public void CallRoleInfoPanelData() {
			db = OpenDb();
			SqliteDataReader sqReader = db.ExecuteQuery("select * from RolesTable where BelongToRoleId = '" + currentRoleId + "'");
			JObject obj = new JObject();
			JArray data = new JArray();
			if (sqReader.Read()) {
				data.Add(new JArray(
					sqReader.GetString(sqReader.GetOrdinal("RoleId")),
					sqReader.GetString(sqReader.GetOrdinal("RoleData")),
					sqReader.GetInt16(sqReader.GetOrdinal("State"))
				));
			}
			obj["data"] = data;
			Messenger.Broadcast<JObject>(NotifyTypes.CallRoleInfoPanelDataEcho, obj);
			db.CloseSqlConnection();
		}
	}
}