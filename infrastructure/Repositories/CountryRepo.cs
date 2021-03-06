using Core.Entities;
using Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Repositories
{
    public class CountryRepo : IGeneric<Country>
    {

        private WorldDbContext _db;
        public CountryRepo(WorldDbContext db)
        {
            _db = db;
        }

        public Country Create(Country country)
        {
            try
            {
                if (country == null)
                {
                    return null;
                }

                _db.Countries.Add(country);
                int affected = _db.SaveChanges();

                if (affected == 1)
                {
                    return country;
                }

                return null;

            }
            catch
            {
                return null;
            }
        }

        public bool Delete(int id)
        {
            try
            {

                Country country = RetriveById(id);
                if (country == null)
                {
                    return false;
                }

                _db.Countries.Remove(country);
                int affected = _db.SaveChanges();

                if (affected == 1)
                {
                    return true;
                }
                return false;

            }
            catch
            {
                return false;
            }

        }

        public Country Patch(Country _country)
        {
            try
            {

                Country country = RetriveById(_country.Id);
                if (country == null)
                {
                    return null;
                }
                country.CountryName = _country.CountryName;
                country.AddedDate = _country.AddedDate;
                int affected = _db.SaveChanges();
                if (affected == 1)
                {
                    return _country;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Country RetriveById(int id)
        {
            try
            {
                return _db.Countries.Single(i => i.Id == id);
            }
            catch
            {
                return null;
            }
        }

        public List<Country> RetriveAll()
        {
            try
            {
                return _db.Countries.ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
