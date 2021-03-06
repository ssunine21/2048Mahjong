using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour, IStoreListener {
	public const string PREMIUM = "premium";

	public bool isPremium;

	private static IAPManager _init;
	public static IAPManager init {
		get {
			if (_init != null) return _init;
			_init = FindObjectOfType<IAPManager>();

			if (_init == null)
				_init = new GameObject("IAPManager").AddComponent<IAPManager>();
			return _init;
		}
	}

	protected IStoreController storeController;
	private IExtensionProvider extensionProvider;

	public bool isInit => storeController != null && extensionProvider != null;

	private void Awake() {
		if(_init != null && _init != this) {
			Destroy(gameObject);
			return;
		}
		DontDestroyOnLoad(gameObject);
		InitUnityIAP();
	}

	private void InitUnityIAP() {
		if (isInit) return;

		var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

		builder.AddProduct(
			PREMIUM, ProductType.NonConsumable, new IDs() {
				{ PREMIUM, GooglePlay.Name }
			}
		);

		UnityPurchasing.Initialize(this, builder);
	}

	public void OnInitialized(IStoreController controller, IExtensionProvider extension) {
		Debug.Log("IAP initalized");
		storeController = controller;
		extensionProvider = extension;

		if (HadPurchased(PREMIUM)) {
			isPremium = true;
			AdsManager.init.DestroyBannerAd();
		}
	}

	public void OnInitializeFailed(InitializationFailureReason error) {
		Debug.LogError($"IAP failed : {error}");
	}

	//purchased reward
	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent) {
		Debug.Log($"PurchaseResult : {purchaseEvent.purchasedProduct.definition.id}");

		switch (purchaseEvent.purchasedProduct.definition.id) {
			case PREMIUM:
				isPremium = true;
				AdsManager.init.DestroyBannerAd();
				break;
		}

		return PurchaseProcessingResult.Complete;
	}

	public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason) {
		Debug.LogError($"PurchaseFailed : {product.definition.id}, {failureReason}");
	}

	public void Purchase(string productId) {
		if (!isInit) return;

		var product = storeController.products.WithID(productId);

		if(product != null && product.availableToPurchase) {
			Debug.Log($"productID : {product.definition.id}");
			storeController.InitiatePurchase(product);
		} else {
			Debug.Log($"not productId {productId}");
		}
	}
	
/*	public void RestorePurchase() {
		if (!isInit) return;
		if(Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.OSXPlayer) {
			Debug.Log("restorePurchase");

			var appleExt = extensionProvider.GetExtension<IAppleExtensions>();
			appleExt.RestoreTransactions(
				result => Debug.Log($"restorePurchase result - {result}"));
		}
	}*/

	public bool HadPurchased(string productId) {
		if (!isInit) return false;
		var product = storeController.products.WithID(productId);

		if (product != null) {
			return product.hasReceipt;
		}

		return false;
	}
}
