const numbers = [];
function maxSubarraySum(arr) {
    if (arr.length === 0) {
      return 0;
    }
  
    let maxEndingHere = arr[0];
    let maxSoFar = arr[0];
  
    for (let i = 1; i < arr.length; i++) {
      maxEndingHere = Math.max(arr[i], maxEndingHere + arr[i]);
      maxSoFar = Math.max(maxSoFar, maxEndingHere);
    }
  
    return maxSoFar;
  }

  function updateNumbersList() {
    const numbersList = document.getElementById('numbersList');
    numbersList.innerHTML = `Entered numbers: ${numbers.join(', ')}`;
  }
  
  function validateInput(inputValue) {
    const inputArray = inputValue.split(',').map(Number);
  
    if (inputArray.some(isNaN)) {
      return false;
    }
  
    return true;
  }
  
  function calculateMaxSubarraySum() {
    const resultElement = document.getElementById('result');
  
    if (numbers.length === 0) {
      alert('Please enter at least one number.');
      resultElement.textContent = ''; 
      return;
    }
  
    const maxSum = maxSubarraySum(numbers);
    resultElement.textContent = `Maximum sum of continuous subarray: ${maxSum}`;
  }
  
  const addButton = document.getElementById('addButton');
  const calculateButton = document.getElementById('calculateButton');
  
  addButton.addEventListener('click', () => {
    const inputElement = document.getElementById('inputArray');
    const inputValue = inputElement.value.trim();
  
    if (inputValue !== '') {
      if (validateInput(inputValue)) {
        const inputArray = inputValue.split(',').map(Number);
        numbers.push(...inputArray);
        updateNumbersList();
        inputElement.value = ''; // Clear input after adding numbers
      } else {
        alert('Please enter valid numbers.');
      }
    }
  });
  
  calculateButton.addEventListener('click', calculateMaxSubarraySum);