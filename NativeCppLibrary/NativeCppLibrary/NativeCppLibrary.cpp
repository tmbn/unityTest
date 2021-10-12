/* NativeCppLibrary.cpp : Defines the exported functions for the DLL.
*/
#include "pch.h"
#include "framework.h"
#include "NativeCppLibrary.h"

// Standard Library imports
#include <iostream>

using namespace std;

struct TwoStrings
{
	string string1;
	string string2;
	string concatenated;
};



int display(TwoStrings *ts)
{
	return 0;

}

void concatenate(TwoStrings $ts)
{
	string temp = $ts.concatenated;
	temp = $ts.string1.append($ts.string2);
	$ts.concatenated = temp;
}
