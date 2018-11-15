using Sample1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample1
{
    public class CitiesStore
    {
        public static CitiesStore Instance { get; } 
            = new CitiesStore();

        public List<CityDto> Cities { get; set; }

        private CitiesStore()
        {
            

            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "천안",
                    Description = "충청남도",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "천안삼거리",
                            Description = "흥타령축제",
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "한국기술교육대학교",
                            Description = "아우내",
                        },
                        new PointOfInterestDto()
                        {
                            Id = 3,
                            Name = "야우리",
                            Description = "터미널 쇼핑",
                        },
                    }
                },

                new CityDto()
                {
                    Id = 2,
                    Name = "서울",
                    Description = "특별시",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "가산",
                            Description = "우리회사",
                        },
                    }
                },

                new CityDto()
                {
                    Id = 3,
                    Name = "부산",
                    Description = "광역시",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "해운대",
                            Description = "비싸",
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "광안리",
                            Description = "회 맛있어",
                        },
                    }
                }
            };

            //CityDto city = new CityDto();
            //city.Id = 1;
            //city.Name = "천안";
            //city.Description = "천안삼거리";

            //CityDto city2 = new CityDto()
            //{
            //    Id = 1,
            //    Name = "천안",
            //    Description = "천안삼거리"
            //};

            //Cities.Add(city);

        }
    }
}
