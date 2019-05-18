using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApp1.DataFormating
{
    class GetDataFromWeb
    {
        public List<Glass> GetGlasses()
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            string webData = wc.DownloadString("http://localhost:2943/Default.aspx");
            int textFrom = webData.IndexOf("<div class=\"table-responsive\">") + "<div class=\"table-responsive\">".Length;
            int textTo = webData.LastIndexOf("</table>") - textFrom;
            string data = webData.Substring(textFrom, textTo);
            data = data.Replace("\r\n", "");
            data = data.Replace(" ", "");
            textFrom = data.IndexOf("<tbody") + "<tbody".Length;
            string dataNew = data.Substring(textFrom);
            int step = 0;
            List<Glass> AllGlass = new List<Glass>();
            foreach (var row in dataNew.Split(new string[] { "<tr>" }, StringSplitOptions.RemoveEmptyEntries))
            {
                step = 0;
                string[] items = row.Split(new string[] { "<td>" }, StringSplitOptions.RemoveEmptyEntries);
                if (items.Count() >= 7)
                {
                    Glass newGlass = new Glass();
                    foreach (var item in items)
                    {
                        textFrom = item.IndexOf(">") + ">".Length;
                        textTo = item.IndexOf("</span></td>") - textFrom;
                        var info = item.Substring(textFrom, textTo);
                        switch (step)
                        {
                            case 0:
                                newGlass.id = int.Parse(info);
                                break;
                            case 1:
                                newGlass.refractive_index = double.Parse(info);
                                break;
                            case 2:
                                newGlass.sodium = double.Parse(info);
                                break;
                            case 3:
                                newGlass.magnesium = double.Parse(info);
                                break;
                            case 4:
                                newGlass.aluminum = double.Parse(info);
                                break;
                            case 5:
                                newGlass.silicon = double.Parse(info);
                                break;
                            case 6:
                                newGlass.potassium = double.Parse(info);
                                break;
                            case 7:
                                newGlass.calcium = double.Parse(info);
                                break;
                            case 8:
                                newGlass.barium = double.Parse(info);
                                break;
                            case 9:
                                newGlass.iron = double.Parse(info);
                                break;
                            case 10:
                                newGlass.group_type = int.Parse(info);
                                break;
                            default:
                                break;
                        }
                        step++;
                    }
                    AllGlass.Add(newGlass);
                }
            }
            return AllGlass;
        }
    }
}
