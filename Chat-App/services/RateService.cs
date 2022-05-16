using Chat_App.Models;

namespace Chat_App.services
{
    public class RateService : IRateService
    {
        private static List<Rate> rates = new List<Rate>();

        public List<Rate> GetAll() { 
            return rates;
        }

        public Rate Get(int Id) { 
            return rates.Find(x => x.Id == Id);
        }

        public void Create(string userName, string description, int value) {
            int nextId = 0;
            if (rates.Count > 0)
            {
                nextId = rates.Max(x => x.Id) + 1;
            }
            rates.Add(new Rate { Id = nextId, UserName = userName, Description = description, Value = value });
        }

        public void Edit(int id, string userName, string description, int value) {
            Rate rate = Get(id);
            rate.UserName = userName;
            rate.Description = description;
            rate.Value = value;
        }

        public void Delete(int id) { 
            rates.Remove(Get(id));
        }
    }
}
