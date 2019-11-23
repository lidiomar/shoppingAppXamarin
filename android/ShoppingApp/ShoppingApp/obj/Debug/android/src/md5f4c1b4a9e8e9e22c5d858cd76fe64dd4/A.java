package md5f4c1b4a9e8e9e22c5d858cd76fe64dd4;


public class A
	extends android.support.v7.widget.RecyclerView.OnScrollListener
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onScrollStateChanged:(Landroid/support/v7/widget/RecyclerView;I)V:GetOnScrollStateChanged_Landroid_support_v7_widget_RecyclerView_IHandler\n" +
			"";
		mono.android.Runtime.register ("ShoppingApp.app.catalog.A, ShoppingApp", A.class, __md_methods);
	}


	public A ()
	{
		super ();
		if (getClass () == A.class)
			mono.android.TypeManager.Activate ("ShoppingApp.app.catalog.A, ShoppingApp", "", this, new java.lang.Object[] {  });
	}

	public A (android.view.View p0, android.support.v7.widget.LinearLayoutManager p1)
	{
		super ();
		if (getClass () == A.class)
			mono.android.TypeManager.Activate ("ShoppingApp.app.catalog.A, ShoppingApp", "Android.Views.View, Mono.Android:Android.Support.V7.Widget.LinearLayoutManager, Xamarin.Android.Support.v7.RecyclerView", this, new java.lang.Object[] { p0, p1 });
	}


	public void onScrollStateChanged (android.support.v7.widget.RecyclerView p0, int p1)
	{
		n_onScrollStateChanged (p0, p1);
	}

	private native void n_onScrollStateChanged (android.support.v7.widget.RecyclerView p0, int p1);

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
