using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class InfoEventArgs<T> : EventArgs 
{
	public T info;
	
	public InfoEventArgs() 
	{
		info = default(T);
	}
	
	public InfoEventArgs (T info)
	{
		this.info = info;
	}
}

public class InfoEventArgs<T,TT> : EventArgs {
    public T type;
    public TT Subtype;

    public InfoEventArgs() {
        type = default(T);
        Subtype = default(TT);
    }

    public InfoEventArgs(T type, TT Subtype) {
        this.type = type;
        this.Subtype = Subtype;
    }
}