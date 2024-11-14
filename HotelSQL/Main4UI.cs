using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections;
using System.Data;
using AntdUI;
using HotelSQL.DataBase;
using HotelSQL.HotelManage;
using HotelSQL;

class MainFunction
{
    [STAThread]
    public static void Main(string[] args)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new LoginForm());
    }
}

