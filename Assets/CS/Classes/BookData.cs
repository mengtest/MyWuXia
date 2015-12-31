﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game {
	public class BookData {
		/// <summary>
		/// The identifier.
		/// </summary>
		public string Id;
		/// <summary>
		/// The name.
		/// </summary>
		public string Name;
		/// <summary>
		/// The desc.
		/// </summary>
		public string Desc;
		/// <summary>
		/// 引用的技能id集合
		/// </summary>
		public List<string> ResourceSkillDataIds;
		/// <summary>
		/// 武功招式集合
		/// </summary>
		public List<SkillData> Skills;
		/// <summary>
		/// Icon Id
		/// </summary>
		public string IconId;

		int currentSkillIndex;
		/// <summary>
		/// 获取当前技能索引
		/// </summary>
		/// <value>The index of the current skill.</value>
		public int CurrentSkillIndex {
			get {
				return currentSkillIndex;
			}
				
		}

		public BookData() {
			ResourceSkillDataIds = new List<string>();
			Skills = new List<SkillData>();
			currentSkillIndex = 0;
		}

		/// <summary>
		/// 获取当前技能
		/// </summary>
		/// <returns>The current skill data.</returns>
		public SkillData GetCurrentSkill() {
			if (Skills == null || Skills.Count == 0) {
				return null;
			}
			return Skills[currentSkillIndex];
		}

		/// <summary>
		/// 使用下一个技能
		/// </summary>
		/// <returns>The skill.</returns>
		public SkillData NextSkill() {
			if (Skills == null || Skills.Count == 0) {
				return null;
			}
			currentSkillIndex++;
			currentSkillIndex %= Skills.Count;
			return Skills[currentSkillIndex];
		}

		/// <summary>
		/// 重头来
		/// </summary>
		public SkillData Restart() {
			if (Skills == null || Skills.Count == 0) {
				return null;
			}
			currentSkillIndex = 0;
			return Skills[currentSkillIndex];
		}
	}
}