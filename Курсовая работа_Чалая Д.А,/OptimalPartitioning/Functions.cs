using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OptimalPartitioning
{
    class Functions
    {
        public Dictionary<string, Func<double, double, double, double, double>> cFuncs = new Dictionary<string, Func<double, double, double, double, double>>()
        {
            {"0.3√((x-x1)²+(y-y1)²)", delegate(double x, double y, double i, double j){
                                        return 0.3 * Math.Sqrt((x - i) * (x - i) + (y - j) * (y - j));}},
            {"0.5√((x-x1)²+(y-y1)²)", delegate(double x, double y, double i, double j){
                                        return 0.5 * Math.Sqrt((x - i) * (x - i) + (y - j) * (y - j));}},
            {"0.8√((x-x1)²+(y-y1)²)", delegate(double x, double y, double i, double j){
                                        return 0.8 * Math.Sqrt((x - i) * (x - i) + (y - j) * (y - j));}},
            {"√((x-x1)²+(y-y1)²)", delegate(double x, double y, double i, double j){
                                        return Math.Sqrt((x - i) * (x - i) + (y - j) * (y - j));}},
            {"10√((x-x1)²+(y-y1)²)", delegate(double x, double y, double i, double j){
                                        return 10 * Math.Sqrt((x - i) * (x - i) + (y - j) * (y - j));}},
            {"((x-x1)²+(y-y1)²)^(0.1)", delegate(double x, double y, double i, double j){
                                        return Math.Pow((x - i) * (x - i) + (y - j) * (y - j), 0.1);}},
            {"Exp(2√(x+y)²)", delegate(double x, double y, double i, double j){
                                        return Math.Exp(2 * Math.Sqrt((x - i) * (x - i) + (y - j) * (y - j)));}},
            {"|(x-x1)²-(y-y1)²|", delegate(double x, double y, double i, double j){
                                        return Math.Abs((x - i) * (x - i) - (y - j) * (y - j));}},
            {"|(x-x1)^4-(y-y1)^4|", delegate(double x, double y, double i, double j){
                                        return Math.Abs(Math.Pow((x - i),4) - Math.Pow((y - j),4));}},
            {"|√(x-x1)^14-(y-y1)^14|", delegate(double x, double y, double i, double j){
                                        double t = 14.0;
                                        return Math.Abs(Math.Pow(Math.Pow((x - i),t) + Math.Pow((y - j),t),1.0/2.0));}},
            {"√(5(x-x1)²+(y-y1)²)", delegate(double x, double y, double i, double j){
                                        return Math.Sqrt(5*(x - i) * (x - i) + (y - j) * (y - j));}},
        };

        public Dictionary<string, Func<double, double, double>> roFuncs = new Dictionary<string, Func<double, double, double>>()
        {
            {"1", delegate(double x, double y){
                                return 1;}},
            {"Exp(2(x+y)²)", delegate(double x, double y){
                                return Math.Exp(2 * (x + y) * (x + y));}},
            {"Exp(3(x+y)²)", delegate(double x, double y){
                                return Math.Exp(3 * (x + y) * (x + y));}},
            {"0.3√(x²+y²)", delegate(double x, double y){
                                return 0.3 * Math.Sqrt(x*x + y*y);}},
            {"0.7√(x²+y²)", delegate(double x, double y){
                                return 0.7 * Math.Sqrt(x*x + y*y);}},
            {"√(x²+y²)", delegate(double x, double y){
                                return Math.Sqrt(x*x + y*y);}},
            {"2√(x²+y²)", delegate(double x, double y){
                                return 2 * Math.Sqrt(x*x + y*y);}},
        };
    }
}
