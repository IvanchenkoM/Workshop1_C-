int rows = 6;
int startingPoint = 7;
int i=1;
double smthCalculation = Math.Round(Convert.ToDouble((1-(rows*startingPoint))/(1-startingPoint)),2);

Console.WriteLine(smthCalculation);
double exactCalculation = Math.Round(Convert.ToDouble((i-smthCalculation)/(rows-smthCalculation)),2);
Console.WriteLine(exactCalculation);

int x = Convert.ToInt32(exactCalculation);