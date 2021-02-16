// Calculator example - This file contains the 'main' function - Program exectution begins and ends there.

#include <iostream>
#include "Calculator.cpp"

using namespace std;

int main()
{
    double x = 0.0;
    double y = 0.0;
    double result = 0.0;
    char oper = '+';

    cout << "Calculator Console App" << endl;
    cout << "Please enter the operation to perform. Format a+b | a-b | a*b | a/b"
        << endl;
    
    Calculator c;

    while (true)
    {
        // Read inputs
        cin >> x >> oper >> y;

        // Handle division by zero
        if (oper == '/' && y == 0)
        {
            cout << "Division by 0 exception" << endl;

            continue;
        }

        else
        {
            // Perform calculation
            result = c.Calculate(x, oper, y);
        }
        
        // Present outputs
        cout << "Result is: " << result << endl;
    }

    return 0;
}