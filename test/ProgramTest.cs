using Xunit;
using Shouldly;

namespace GoogleDistanceMatrix
{
    public class ProgramTest
    {
        [Fact]
        public void DistanceMatrixConfigTest()
        {
            DistanceMatrixConfig conf = new DistanceMatrixConfig();
            conf.AddParam = "Manchester";
            conf.Url.ShouldContain("Manchester");
        }

        [Fact]
        public void ApiCallerTest()
        {
            ApiCaller api = new ApiCaller("https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins=Manchester,UK&destinations=London,UK&key=AIzaSyDYNG45WSHzldnr6HzwHkdjP4lIXGFlZb4");
            var response = api.Response;
            response.ToString().ShouldContain("distance");
            response.ToString().ShouldContain("duration");
        }

    }
}