using System;

namespace AspNetCoreTodo.Models
{
    public class TodoItem
    {
        /// <summary>
        /// Id 属性是一个Guid.
        /// guid 是随机的，并极少会有重复值，所以常被用作唯一标识。
        /// 也可以用数字（整形 integer）作为数据库记录的标识
        /// </summary>
        public Guid Id { get; set; }

        public bool IsDone { get; set; }
        /// <summary>
        /// Title 属性是一个字符串，用于保存待办事项的名称或者简述。
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// DueAt 属性是一个 DateTimeOffset，
        /// C# 用于这种类型保存一个 日期/时间 的戳记和一个与 UTC 偏移量表示的时区。
        /// 把时期、时间和时区一起保存，有助于在不同时区的系统上准确地显示时间。
        /// </summary>
        public DateTimeOffset? DueAt { get; set; }
    }
}
