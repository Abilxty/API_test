using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data{
    public class MockCommanderRepo : ICommanderRepo{

        public IEnumerable<Command> GetAppCommands(){

            var commands = new List<Command>{

                new Command{Id=0, HowTo="Boil an egg", Line="Boil water", Platform="Kettle & Pan"},
                new Command{Id=0, HowTo="Cut Bread", Line="Get a knife", Platform="Kitchen"},
                new Command{Id=0, HowTo="Make cup of tea", Line="Prepare tea bag", Platform="Kettle & Cup"}
            };

            return commands;
        } 

        public Command GetCommandById(int id){
            
            	return new Command{Id=0, HowTo="Boil an egg", Line="Boil water", Platform="Kettle & Pan"};
        }
    }
}