# 2D_Popup_System
An application whose primary goal is to queue different types of pop-ups with dynamic assets setup and loaded sprites by URL.

Unity version: 2020.3.45f1.
Screen resolutions: 16:9 portrait, 18:9 portrait.

Extended assets used:

TextMesh Pro – for better work with texts.

Demigiandt DOTween Pro – for making simple animations, this asset is designer-friendly. You can make nice animation without writing code.

I decided to use this screen resolution because most simple mobile games are played with one hand in portrait mode. 

Main systems:
Popup system:
To show a new popup, you need to use one of the buttons on the main screen. Before the popup is shown, it is added to the global popup queue (this queue is based on shared variables), checking for an active popup. If there is none, this new popup will be shown on the main screen. Other popups will wait in the queue if there is an active popup. There are a few popup types:

Basic popup with title, message field, and button.

Scheduled popup. It has the same parameters as in the basic popup, but you can choose the time delay when this popup must be shown.

Popup with multiple options. There are a few toggles that must be marked before confirm button activates.

Popup with a link. It has the same parameters as the basic popup, but you will open the URL by pressing the button. You can click on its dark background to close this popup without opening the URL.

Every single popup can be configured by his popup setup made by scriptable objects. You can choose from basic options such as title, message, button text, background image address, and button image address. Or unique options like scheduled time, link address or image addresses for a popup with multiple options. I used SO because it is the best way to make dynamic assets I tried as much as possible to make this system designer friendly, so they could change much of this using only Unity Editor, so I didn't use “AddListener” or “GetComponent” methods.

Image handling system:

I used Unity web request: “UnityWebRequestTexture.GetTexture” in “SpriteCreator” to use dynamic sprites. There are a few types of image handlers:
 
Single Image Handler – to load a single image, for example, for the main background. 

Multiple Image Handler – to load a group of images. Used in popup with multiple options to load images for toggles.

Popup Image Handler – at the start of this program, “PopupSystemController” uses “PopupImageHandler” to get images to popups.
