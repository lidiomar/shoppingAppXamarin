package md5f44916c0bbb54411549afcb02c1a44b5;


public class ClickChangeItemCount
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.view.View.OnClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onClick:(Landroid/view/View;)V:GetOnClick_Landroid_view_View_Handler:Android.Views.View/IOnClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("ShoppingApp.app.catalog.view.ClickChangeItemCount, ShoppingApp", ClickChangeItemCount.class, __md_methods);
	}


	public ClickChangeItemCount ()
	{
		super ();
		if (getClass () == ClickChangeItemCount.class)
			mono.android.TypeManager.Activate ("ShoppingApp.app.catalog.view.ClickChangeItemCount, ShoppingApp", "", this, new java.lang.Object[] {  });
	}

	public ClickChangeItemCount (int p0, md5f44916c0bbb54411549afcb02c1a44b5.CatalogViewHolder p1, int p2, md5f44916c0bbb54411549afcb02c1a44b5.CatalogAdapter p3)
	{
		super ();
		if (getClass () == ClickChangeItemCount.class)
			mono.android.TypeManager.Activate ("ShoppingApp.app.catalog.view.ClickChangeItemCount, ShoppingApp", "System.Int32, mscorlib:ShoppingApp.app.catalog.view.CatalogViewHolder, ShoppingApp:System.Int32, mscorlib:ShoppingApp.app.catalog.view.CatalogAdapter, ShoppingApp", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public void onClick (android.view.View p0)
	{
		n_onClick (p0);
	}

	private native void n_onClick (android.view.View p0);

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
