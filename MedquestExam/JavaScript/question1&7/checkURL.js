function isUrlAvailable(url) {
  
  //Check if the URL is a valid URL.
  if (!isValidUrl(url)) {
    return false;
  }

  let xhr = new XMLHttpRequest();

  xhr.open("GET", url, true);

  //check if the request is success, 4 = success
  xhr.onreadystatechange = function() {
    if (xhr.readyState === 4) {
      // Check the status code.
      if (xhr.status === 200) {
        return true;
      } else {
        return false;
      }
    }
  };
}

// Function to check if a string is a valid URL.
function isValidUrl(url) {
  // Try to create a URL object from the string.
  let parsedUrl;
  
  
  //Check if the format of string is valid URL
  try {
    parsedUrl = new URL(url);
  } catch (e) {
    return false;
  }

  // Check if the protocol is HTTP or HTTPS.
  if (parsedUrl.protocol !== "http:" && parsedUrl.protocol !== "https:") {
    // The URL is not a valid HTTP or HTTPS URL.
    return false;
  }

  // The URL is valid.
  return true;
}

const isAvailable = isUrlAvailable("https://www.google.com");
console.log(isAvailable);