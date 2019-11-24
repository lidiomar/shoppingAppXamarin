package md5637e927b7e94b54641ff311953113206;


public class ShoppingCartViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("ShoppingApp.app.cart.view.ShoppingCartViewHolder, ShoppingApp", ShoppingCartViewHolder.class, __md_methods);
	}


	public ShoppingCartViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == ShoppingCartViewHolder.class)
			mono.android.TypeManager.Activate ("ShoppingApp.app.cart.view.ShoppingCartViewHolder, ShoppingApp", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

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
