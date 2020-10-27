using System;

namespace AspNetCoreTodo.Models
{
    public class TodoItem
    {
        /// <summary>
        /// Id ������һ��Guid.
        /// guid ������ģ������ٻ����ظ�ֵ�����Գ�������Ψһ��ʶ��
        /// Ҳ���������֣����� integer����Ϊ���ݿ��¼�ı�ʶ
        /// </summary>
        public Guid Id { get; set; }

        public bool IsDone { get; set; }
        /// <summary>
        /// Title ������һ���ַ��������ڱ��������������ƻ��߼�����
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// DueAt ������һ�� DateTimeOffset��
        /// C# �����������ͱ���һ�� ����/ʱ�� �Ĵ��Ǻ�һ���� UTC ƫ������ʾ��ʱ����
        /// ��ʱ�ڡ�ʱ���ʱ��һ�𱣴棬�������ڲ�ͬʱ����ϵͳ��׼ȷ����ʾʱ�䡣
        /// </summary>
        public DateTimeOffset? DueAt { get; set; }
    }
}
