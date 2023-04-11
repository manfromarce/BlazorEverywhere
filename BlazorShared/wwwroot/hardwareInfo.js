// This is a JavaScript module that is loaded on demand. It can export any number of
// functions, and may import other JavaScript modules if required.

export function getOs() {

    // Don't change order, as some user agents may contain other identifiers, 
    // e.g. Android user agents usually also contain "Linux"

    if (navigator.userAgent.toUpperCase().indexOf("WINDOWS") != -1 ||
        navigator.userAgent.toUpperCase().indexOf("WINNT") != -1 || 
        navigator.userAgent.toUpperCase().indexOf("WIN32") != -1 || 
        navigator.userAgent.toUpperCase().indexOf("WIN64") != -1)
        return "Windows";

    if (navigator.userAgent.toUpperCase().indexOf("IPHONE") != -1 ||
        navigator.userAgent.toUpperCase().indexOf("IPAD") != -1 || 
        navigator.userAgent.toUpperCase().indexOf("IPOD") != -1)
        return "iOS";

    if (navigator.userAgent.toUpperCase().indexOf("APPLETV") != -1 ||
        navigator.userAgent.toUpperCase().indexOf("APPLE TV") != -1 ||
        navigator.userAgent.toUpperCase().indexOf("TVOS") != -1)
        return "tvOS";

    if (navigator.userAgent.toUpperCase().indexOf("MAC") != -1)
        return "MacOS";

    if (navigator.userAgent.toUpperCase().indexOf("TIZEN") != -1)
        return "Tizen";

    if (navigator.userAgent.toUpperCase().indexOf("WEBOS") != -1 || 
        navigator.userAgent.toUpperCase().indexOf("WEB0S") != -1)
        return "WebOS";

    if (navigator.userAgent.toUpperCase().indexOf("CHROMEOS") != -1 ||
        navigator.userAgent.toUpperCase().indexOf("CROS") != -1 ||
        navigator.userAgent.toUpperCase().indexOf("CHROMEBOOK") != -1)
        return "Chrome OS";

    if (navigator.userAgent.toUpperCase().indexOf("ANDROID") != -1 || 
        navigator.userAgent.toUpperCase().indexOf("ANDR0ID"))
        return "Android";

    if (navigator.userAgent.toUpperCase().indexOf("LINUX") != -1)
        return "Linux";

    if (navigator.userAgent.toUpperCase().indexOf("BSD") != -1)
        return "BSD";

    if (navigator.userAgent.toUpperCase().indexOf("X11") != -1)
        return "UNIX";

    if (navigator.userAgent.toUpperCase().indexOf("PLAYSTATION") != -1)
        return "PlayStation";

    if (navigator.userAgent.toUpperCase().indexOf("X11") != -1)
        return "Nintendo Switch";

    return "Unknown OS";
}