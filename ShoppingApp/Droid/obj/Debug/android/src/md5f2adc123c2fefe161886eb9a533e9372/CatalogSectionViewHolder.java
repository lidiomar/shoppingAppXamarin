package md5f2adc123c2fefe161886eb9a533e9372;


public class CatalogSectionViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Droid.app.catalog.CatalogSectionViewHolder, ShoppingApp", CatalogSectionViewHolder.class, __md_methods);
	}


	public CatalogSectionViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == CatalogSectionViewHolder.class)
			mono.android.TypeManager.Activate ("Droid.app.catalog.CatalogSectionViewHolder, ShoppingApp", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
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