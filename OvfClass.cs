using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace GUI_OVFTOOL
{
    class OvfClass
    {
        public String eula_chk(String l)
        {
            try
            {
                String eul;
                ProcessStartInfo psii = new ProcessStartInfo(@"C:\Program Files\VMware\VMware OVF Tool\ovftool.exe", l);
                psii.UseShellExecute = false;
                psii.RedirectStandardOutput = true;
                psii.CreateNoWindow = true;
                var proc = Process.Start(psii);
                eul = proc.StandardOutput.ReadToEnd();
                if (eul.Contains("End-user License Agreements:"))                
                    return eul;                
                else
                    return null;               
            }
            catch (Exception a)
            {
                return a.Message;
            }
        }
        //public String conf_chk(String c)
        //{
        //    try
        //    {
        //        String conf="",ret;
        //        ProcessStartInfo psii = new ProcessStartInfo(@"C:\Program Files\VMware\VMware OVF Tool\ovftool.exe", c);
        //        psii.UseShellExecute = false;
        //        psii.RedirectStandardOutput = true;
        //        psii.CreateNoWindow = true;
        //        var proc = Process.Start(psii);
        //        conf = proc.StandardOutput.ReadToEnd();
                 
        //        if (conf.Contains("ExtraConfig options exists in source"))
        //            return "ExtraConfig";
        //        else
        //            ret= "";
        //        return ret;
        //    }
        //    catch (Exception a)
        //    {
        //        return a.Message;
        //    }
        //}
        //public String ssl_chk(String c)
        //{
        //    try
        //    {
        //        String conf = "", ret;
        //        ProcessStartInfo psii = new ProcessStartInfo(@"C:\Program Files\VMware\VMware OVF Tool\ovftool.exe", c);
        //        psii.UseShellExecute = false;
        //        psii.RedirectStandardOutput = true;
        //        psii.CreateNoWindow = true;
        //        var proc = Process.Start(psii);
        //        for(int i=0;i<4;i++)
        //        {
        //            conf += proc.StandardOutput.ReadLine();
        //        }
                
        //        if (conf.Contains("Accept SSL fingerprint"))
        //            return conf;
        //        else
        //            ret = "";
        //        return ret;
        //    }
        //    catch (Exception a)
        //    {
        //        return a.Message;
        //    }
        //}
        
        public String compute(String s)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = @"C:\Program Files\VMware\VMware OVF Tool\ovftool.exe";
                psi.Arguments = s;
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
                psi.CreateNoWindow = true;
                var proc = Process.Start(psi);
                String tex = proc.StandardOutput.ReadToEnd();
                return tex;                
            }
            catch(Exception a)
            {
                return a.Message+"erro";                
            }
        }

        //public String compute(String s, Object frm)
        //{
        //    String tex = "", res = "";
        //    String fr = "", cse = "";
        //    int dot = 0, comma = 0, len = 0;
        //    try
        //    {
        //        fr = frm.ToString();
        //        dot = fr.IndexOf(".") + 1;
        //        comma = fr.IndexOf(",");
        //        len = comma - dot;
        //        cse = fr.Substring(dot, len);                
        //        ProcessStartInfo psi = new ProcessStartInfo();
        //        psi.FileName = @"C:\Program Files\VMware\VMware OVF Tool\ovftool.exe";
        //        psi.Arguments = s;
        //        psi.UseShellExecute = false;
        //        psi.RedirectStandardOutput = true;
        //        psi.CreateNoWindow = true;
        //        var proc = Process.Start(psi);
        //        String te = "", tf = "";
        //        te = proc.StandardOutput.ReadLine();
        //        tex += te + Environment.NewLine;
        //        ISO_UpldVCD fs = new ISO_UpldVCD();
        //        fs.progress(10, tex);
        //        //switch (cse)
        //        //{
        //        //    case "Help": Help fsh = new Help();fsh.progress(10, tex); break;
        //        //    case "OVF_Conv": OVF_Conv fsf = new OVF_Conv();fsf.progress(10, tex); break;
        //        //    case "OVA_Conv":OVA_Conv fsa = new OVA_Conv();fsa.progress(10, tex); break;
        //        //    case "VM_Conv": new VM_Conv().progress(10, tex); break;
        //        //    case "Mig_Hosts": new Mig_Hosts().progress(10, tex); break;
        //        //    case "VM_Dowld": new VM_Dowld().progress(10, tex); break;
        //        //    case "Dply_Esxi": new Dply_Esxi().progress(10, tex); break;
        //        //    case "OVF_UpldVCD": new OVF_UpldVCD().progress(2, tex); break;
        //        //    case "ISO_UpldVCD":ISO_UpldVCD fsi = new ISO_UpldVCD();fsi.progress(2, tex); break;
        //        //    case "VM_DowlVCD": new VM_DowlVCD().progress(10, tex); break;
        //        //    case "EULA": new EULA().progress(2, tex); break;
        //        //    default: break;
        //        //}
        //        te = proc.StandardOutput.ReadLine();
        //        tex += te + Environment.NewLine;

        //        te = proc.StandardOutput.ReadLine();
        //        tex += te + Environment.NewLine;
        //        switch (cse)
        //        {
        //            case "Help": new Help().progress(10, tex); break;
        //            case "OVF_Conv": new OVF_Conv().progress(10, tex); break;
        //            case "OVA_Conv": new OVA_Conv().progress(10, tex); break;
        //            case "VM_Conv": new VM_Conv().progress(10, tex); break;
        //            case "Mig_Hosts": new Mig_Hosts().progress(10, tex); break;
        //            case "VM_Dowld": new VM_Dowld().progress(10, tex); break;
        //            case "Dply_Esxi": new Dply_Esxi().progress(10, tex); break;
        //            case "OVF_UpldVCD": new OVF_UpldVCD().progress(3, tex); break;
        //            case "ISO_UpldVCD": new ISO_UpldVCD().progress(3, tex); break;
        //            case "VM_DowlVCD": new VM_DowlVCD().progress(10, tex); break;
        //            case "EULA": new EULA().progress(3, tex); break;
        //            default: break;
        //        }
        //        te = proc.StandardOutput.ReadLine();
        //        tex += te + Environment.NewLine;
        //        te = proc.StandardOutput.ReadLine();
        //        tex += te + Environment.NewLine;
        //        switch (cse)
        //        {
        //            case "Help": new Help().progress(10, tex); break;
        //            case "OVF_Conv": new OVF_Conv().progress(10, tex); break;
        //            case "OVA_Conv": new OVA_Conv().progress(10, tex); break;
        //            case "VM_Conv": new VM_Conv().progress(10, tex); break;
        //            case "Mig_Hosts": new Mig_Hosts().progress(10, tex); break;
        //            case "VM_Dowld": new VM_Dowld().progress(10, tex); break;
        //            case "Dply_Esxi": new Dply_Esxi().progress(10, tex); break;
        //            case "OVF_UpldVCD": new OVF_UpldVCD().progress(5, tex); break;
        //            case "ISO_UpldVCD": new ISO_UpldVCD().progress(5, tex); break;
        //            case "VM_DowlVCD": new VM_DowlVCD().progress(10, tex); break;
        //            case "EULA": new EULA().progress(5, tex); break;
        //            default: break;
        //        }
        //        for (int i = 0; i < 5; i++)
        //        {
        //            if (tf == "Username")
        //            {
        //                res = "Please enter proper username and password \n" + tex + "erro";

        //                return res;
        //            }
        //            te = proc.StandardOutput.ReadLine();
        //            tex += te + Environment.NewLine;
        //            if (te == null)
        //            {
        //                break;
        //            }
        //            if (te == "")
        //            {
        //                continue;
        //            }
        //            else
        //            {
        //                if (te.Length >= 8)
        //                {
        //                    tf = te.Substring(0, 8);
        //                }
        //            }
        //        }
        //        switch (cse)
        //        {
        //            case "Help": new Help().progress(10, tex); break;
        //            case "OVF_Conv": new OVF_Conv().progress(10, tex); break;
        //            case "OVA_Conv": new OVA_Conv().progress(10, tex); break;
        //            case "VM_Conv": new VM_Conv().progress(10, tex); break;
        //            case "Mig_Hosts": new Mig_Hosts().progress(10, tex); break;
        //            case "VM_Dowld": new VM_Dowld().progress(10, tex); break;
        //            case "Dply_Esxi": new Dply_Esxi().progress(10, tex); break;
        //            case "OVF_UpldVCD": new OVF_UpldVCD().progress(10, tex); break;
        //            case "ISO_UpldVCD": new ISO_UpldVCD().progress(10, tex); break;
        //            case "VM_DowlVCD": new VM_DowlVCD().progress(10, tex); break;
        //            case "EULA": new EULA().progress(10, tex); break;
        //            default: break;
        //        }
        //        for (int i = 0; i < 10; i++)
        //        {
        //            if (te == null)
        //            {
        //                break;
        //            }
        //            te = proc.StandardOutput.ReadLine();
        //            tex += te + Environment.NewLine;

        //        }
        //        switch (cse)
        //        {
        //            case "Help": new Help().progress(10, tex); break;
        //            case "OVF_Conv": new OVF_Conv().progress(10, tex); break;
        //            case "OVA_Conv": new OVA_Conv().progress(10, tex); break;
        //            case "VM_Conv": new VM_Conv().progress(10, tex); break;
        //            case "Mig_Hosts": new Mig_Hosts().progress(10, tex); break;
        //            case "VM_Dowld": new VM_Dowld().progress(10, tex); break;
        //            case "Dply_Esxi": new Dply_Esxi().progress(10, tex); break;
        //            case "OVF_UpldVCD": new OVF_UpldVCD().progress(20, tex); break;
        //            case "ISO_UpldVCD": new ISO_UpldVCD().progress(20, tex); break;
        //            case "VM_DowlVCD": new VM_DowlVCD().progress(10, tex); break;
        //            case "EULA": new EULA().progress(20, tex); break;
        //            default: break;
        //        }
        //        for (int i = 0; i < 10; i++)
        //        {
        //            if (te == null)
        //            {
        //                break;
        //            }
        //            te = proc.StandardOutput.ReadLine();
        //            tex += te + Environment.NewLine;
        //        }
        //        switch (cse)
        //        {
        //            case "Help": new Help().progress(10, tex); break;
        //            case "OVF_Conv": new OVF_Conv().progress(10, tex); break;
        //            case "OVA_Conv": new OVA_Conv().progress(10, tex); break;
        //            case "VM_Conv": new VM_Conv().progress(10, tex); break;
        //            case "Mig_Hosts": new Mig_Hosts().progress(10, tex); break;
        //            case "VM_Dowld": new VM_Dowld().progress(10, tex); break;
        //            case "Dply_Esxi": new Dply_Esxi().progress(10, tex); break;
        //            case "OVF_UpldVCD": new OVF_UpldVCD().progress(30, tex); break;
        //            case "ISO_UpldVCD": new ISO_UpldVCD().progress(30, tex); break;
        //            case "VM_DowlVCD": new VM_DowlVCD().progress(10, tex); break;
        //            case "EULA": new EULA().progress(30, tex); break;
        //            default: break;
        //        }
        //        for (int i = 0; i < 10; i++)
        //        {
        //            if (te == null)
        //            {
        //                break;
        //            }
        //            te = proc.StandardOutput.ReadLine();
        //            tex += te + Environment.NewLine;
        //        }
        //        switch (cse)
        //        {
        //            case "Help": new Help().progress(10, tex); break;
        //            case "OVF_Conv": new OVF_Conv().progress(10, tex); break;
        //            case "OVA_Conv": new OVA_Conv().progress(10, tex); break;
        //            case "VM_Conv": new VM_Conv().progress(10, tex); break;
        //            case "Mig_Hosts": new Mig_Hosts().progress(10, tex); break;
        //            case "VM_Dowld": new VM_Dowld().progress(10, tex); break;
        //            case "Dply_Esxi": new Dply_Esxi().progress(10, tex); break;
        //            case "OVF_UpldVCD": new OVF_UpldVCD().progress(40, tex); break;
        //            case "ISO_UpldVCD": new ISO_UpldVCD().progress(40, tex); break;
        //            case "VM_DowlVCD": new VM_DowlVCD().progress(10, tex); break;
        //            case "EULA": new EULA().progress(40, tex); break;
        //            default: break;
        //        }
        //        for (int i = 0; i < 10; i++)
        //        {
        //            if (te == null)
        //            {
        //                break;
        //            }
        //            te = proc.StandardOutput.ReadLine();
        //            tex += te + Environment.NewLine;
        //        }
        //        switch (cse)
        //        {
        //            case "Help": new Help().progress(10, tex); break;
        //            case "OVF_Conv": new OVF_Conv().progress(10, tex); break;
        //            case "OVA_Conv": new OVA_Conv().progress(10, tex); break;
        //            case "VM_Conv": new VM_Conv().progress(10, tex); break;
        //            case "Mig_Hosts": new Mig_Hosts().progress(10, tex); break;
        //            case "VM_Dowld": new VM_Dowld().progress(10, tex); break;
        //            case "Dply_Esxi": new Dply_Esxi().progress(10, tex); break;
        //            case "OVF_UpldVCD": new OVF_UpldVCD().progress(50, tex); break;
        //            case "ISO_UpldVCD": new ISO_UpldVCD().progress(50, tex); break;
        //            case "VM_DowlVCD": new VM_DowlVCD().progress(10, tex); break;
        //            case "EULA": new EULA().progress(50, tex); break;
        //            default: break;
        //        }
        //        for (int i = 0; i < 10; i++)
        //        {
        //            if (te == null)
        //            {
        //                break;
        //            }
        //            te = proc.StandardOutput.ReadLine();
        //            tex += te + Environment.NewLine;
        //        }
        //        switch (cse)
        //        {
        //            case "Help": new Help().progress(10, tex); break;
        //            case "OVF_Conv": new OVF_Conv().progress(10, tex); break;
        //            case "OVA_Conv": new OVA_Conv().progress(10, tex); break;
        //            case "VM_Conv": new VM_Conv().progress(10, tex); break;
        //            case "Mig_Hosts": new Mig_Hosts().progress(10, tex); break;
        //            case "VM_Dowld": new VM_Dowld().progress(10, tex); break;
        //            case "Dply_Esxi": new Dply_Esxi().progress(10, tex); break;
        //            case "OVF_UpldVCD": new OVF_UpldVCD().progress(60, tex); break;
        //            case "ISO_UpldVCD": new ISO_UpldVCD().progress(60, tex); break;
        //            case "VM_DowlVCD": new VM_DowlVCD().progress(10, tex); break;
        //            case "EULA": new EULA().progress(60, tex); break;
        //            default: break;
        //        }
        //        for (int i = 0; i < 10; i++)
        //        {
        //            if (te == null)
        //            {
        //                break;
        //            }
        //            te = proc.StandardOutput.ReadLine();
        //            tex += te + Environment.NewLine;
        //        }
        //        switch (cse)
        //        {
        //            case "Help": new Help().progress(10, tex); break;
        //            case "OVF_Conv": new OVF_Conv().progress(10, tex); break;
        //            case "OVA_Conv": new OVA_Conv().progress(10, tex); break;
        //            case "VM_Conv": new VM_Conv().progress(10, tex); break;
        //            case "Mig_Hosts": new Mig_Hosts().progress(10, tex); break;
        //            case "VM_Dowld": new VM_Dowld().progress(10, tex); break;
        //            case "Dply_Esxi": new Dply_Esxi().progress(10, tex); break;
        //            case "OVF_UpldVCD": new OVF_UpldVCD().progress(70, tex); break;
        //            case "ISO_UpldVCD": new ISO_UpldVCD().progress(70, tex); break;
        //            case "VM_DowlVCD": new VM_DowlVCD().progress(10, tex); break;
        //            case "EULA": new EULA().progress(70, tex); break;
        //            default: break;
        //        }
        //        for (int i = 0; i < 10; i++)
        //        {
        //            if (te == null)
        //            {
        //                break;
        //            }
        //            te = proc.StandardOutput.ReadLine();
        //            tex += te + Environment.NewLine;
        //        }
        //        switch (cse)
        //        {
        //            case "Help": new Help().progress(10, tex); break;
        //            case "OVF_Conv": new OVF_Conv().progress(10, tex); break;
        //            case "OVA_Conv": new OVA_Conv().progress(10, tex); break;
        //            case "VM_Conv": new VM_Conv().progress(10, tex); break;
        //            case "Mig_Hosts": new Mig_Hosts().progress(10, tex); break;
        //            case "VM_Dowld": new VM_Dowld().progress(10, tex); break;
        //            case "Dply_Esxi": new Dply_Esxi().progress(10, tex); break;
        //            case "OVF_UpldVCD": new OVF_UpldVCD().progress(80, tex); break;
        //            case "ISO_UpldVCD": new ISO_UpldVCD().progress(80, tex); break;
        //            case "VM_DowlVCD": new VM_DowlVCD().progress(10, tex); break;
        //            case "EULA": new EULA().progress(80, tex); break;
        //            default: break;
        //        }
        //        for (int i = 0; i < 10; i++)
        //        {
        //            if (te == null)
        //            {
        //                break;
        //            }
        //            te = proc.StandardOutput.ReadLine();
        //            tex += te + Environment.NewLine;
        //        }
        //        switch (cse)
        //        {
        //            case "Help": new Help().progress(10, tex); break;
        //            case "OVF_Conv": new OVF_Conv().progress(10, tex); break;
        //            case "OVA_Conv": new OVA_Conv().progress(10, tex); break;
        //            case "VM_Conv": new VM_Conv().progress(10, tex); break;
        //            case "Mig_Hosts": new Mig_Hosts().progress(10, tex); break;
        //            case "VM_Dowld": new VM_Dowld().progress(10, tex); break;
        //            case "Dply_Esxi": new Dply_Esxi().progress(10, tex); break;
        //            case "OVF_UpldVCD": new OVF_UpldVCD().progress(90, tex); break;
        //            case "ISO_UpldVCD": new ISO_UpldVCD().progress(90, tex); break;
        //            case "VM_DowlVCD": new VM_DowlVCD().progress(10, tex); break;
        //            case "EULA": new EULA().progress(90, tex); break;
        //            default: break;
        //        }
        //        for (int i = 0; i < 10; i++)
        //        {
        //            if (te == null)
        //            {
        //                break;
        //            }
        //            te = proc.StandardOutput.ReadLine();
        //            tex += te + Environment.NewLine;
        //        }
        //        switch (cse)
        //        {
        //            case "Help": new Help().progress(10, tex); break;
        //            case "OVF_Conv": new OVF_Conv().progress(10, tex); break;
        //            case "OVA_Conv": new OVA_Conv().progress(10, tex); break;
        //            case "VM_Conv": new VM_Conv().progress(10, tex); break;
        //            case "Mig_Hosts": new Mig_Hosts().progress(10, tex); break;
        //            case "VM_Dowld": new VM_Dowld().progress(10, tex); break;
        //            case "Dply_Esxi": new Dply_Esxi().progress(10, tex); break;
        //            case "OVF_UpldVCD": new OVF_UpldVCD().progress(100, tex); break;
        //            case "ISO_UpldVCD": new ISO_UpldVCD().progress(100, tex); break;
        //            case "VM_DowlVCD": new VM_DowlVCD().progress(10, tex); break;
        //            case "EULA": new EULA().progress(100, tex); break;
        //            default: break;
        //        }
        //        proc.StandardOutput.Dispose();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //    return tex;
        //}
        //Checking weather the file has a end user agreement or not        
    }
}
