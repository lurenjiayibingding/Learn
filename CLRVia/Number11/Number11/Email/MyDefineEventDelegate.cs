using System;
using System.Collections.Generic;
using System.Threading;

namespace Email
{
    public delegate void CatDelegate(Cat cat);

    public delegate void MouseDelegate(Mouse mouse);

    /// <summary>
    /// 猫
    /// </summary>
    public class Cat
    {
        /// <summary>
        /// 名字
        /// </summary>
        private string name;

        /// <summary>
        /// 名字
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// 猫叫事件
        /// </summary>
        public event CatDelegate yell;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name"></param>
        public Cat(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 触发猫叫事件的方法
        /// </summary>
        public void OnCatYell()
        {
            Console.WriteLine($"猫{name}叫了一声");
            var temp = Interlocked.CompareExchange(ref yell, null, null);
            if (temp != null)
            {
                temp(this);
            }
        }
    }

    /// <summary>
    /// 老鼠
    /// </summary>
    public class Mouse
    {
        /// <summary>
        /// 名字
        /// </summary>
        private readonly string name;

        /// <summary>
        /// 老鼠跑动事件
        /// </summary>
        public event MouseDelegate run;

        /// <summary>
        /// 名字
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name"></param>
        public Mouse(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// 老鼠发现猫，注册对猫叫事件的监听
        /// </summary>
        /// <param name="cat"></param>
        public void FindCat(Cat cat)
        {
            cat.yell += RunAway;
        }

        /// <summary>
        /// 老鼠摆脱猫，移除对猫叫事件的监听
        /// </summary>
        /// <param name="cat"></param>
        public void CastOffCat(Cat cat)
        {
            cat.yell -= RunAway;
        }

        /// <summary>
        /// 老鼠听见猫叫之后开始逃窜
        /// </summary>
        /// <param name="cat"></param>
        public void RunAway(Cat cat)
        {
            Console.WriteLine($"老鼠{name}听到了{cat.Name}的叫声开始逃窜");

            var temp = Interlocked.CompareExchange(ref run, null, null);
            if (run != null)
            {
                run(this);
            }
        }

        /// <summary>
        /// 生成一个老鼠集合
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static List<Mouse> CreateList(int length)
        {
            var list = new List<Mouse>();
            for (int i = 0; i < length; i++)
            {
                list.Add(new Mouse("Jerry" + i.ToString()));
            }
            return list;
        }
    }

    /// <summary>
    /// 灯台
    /// </summary>
    public class Candle
    {
        /// <summary>
        /// 序号
        /// </summary>
        private readonly int serial;

        /// <summary>
        /// 序号
        /// </summary>
        /// <param name="serial"></param>
        public Candle(int serial)
        {
            this.serial = serial;
        }

        /// <summary>
        /// 监听老鼠逃窜事件
        /// </summary>
        /// <param name="mouse"></param>
        public void MouseRun(Mouse mouse)
        {
            mouse.run += MouseRun;
        }

        /// <summary>
        /// 老鼠逃窜事件触发时执行的操作：灯台被打翻
        /// </summary>
        /// <param name="mouse"></param>
        public void Overturn(Mouse mouse)
        {
            Console.WriteLine($"{serial.ToString()}号灯台被老鼠{mouse.Name}打翻");
        }
    }
}