package md5fa95414632f8456ef0a9eaa0e95a4670;


public class Activity1
	extends md59e336b20c5f59a4196ec0611a339f132.AndroidGameActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Game9.Activity1, Game9, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Activity1.class, __md_methods);
	}


	public Activity1 () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Activity1.class)
			mono.android.TypeManager.Activate ("Game9.Activity1, Game9, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
