using AutoFixture;
using Microsoft.AspNetCore.Hosting;
using WordGuess.Web.Services;

namespace WordleWirzard.Test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        //ARRANGE
        var _fixture = new Fixture();

        var hostingEvironment = _fixture.Create<IHostingEnvironment>();
     
        var sut = new EliminationWordService(hostingEvironment);

        var possibleWord = new List<string>() { "offer", "fewer", "wafer"};
        
        //ACT
        var result = sut.GetOverallScoreSmashWord3("offer" , );
        //ASSERT
    }
}