using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class NativeCppLibraryIntegration: MonoBehaviour {

    public static TwoStrings ts;

[DllImport("NativeCppLibrary", EntryPoint = "concatenate")]
public static extern string concatenate(TwoStrings ts );

void Start() {
    ts.string1="Hello ";
    ts.string2="World";
    concatenate(ts);
    print(ts.concatenated);

    }




}
public struct TwoStrings
{
	public string string1;
	public string string2;
	public string concatenated;
};