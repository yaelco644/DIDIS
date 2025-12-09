using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FoodDAL
    {
        public FoodDAL() { }
        public List<Food> SelectAllStudent()
        {
            List<Food> foods = new List<Food>();
            DataTable dt = SQLHelper.SelectData("select * from FoodTBL");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // יוצרת משתמש
                string name = dt.Rows[i]["name"].ToString();
                float price = Convert.ToInt32(dt.Rows[i]["price"].ToString());
                string image = dt.Rows[i]["image"].ToString();

                Food food = new Food(name, price, image);

                // מכניסה אותו לרשימה
                foods.Add(food);
            }
            return foods;
        }
    }
}
