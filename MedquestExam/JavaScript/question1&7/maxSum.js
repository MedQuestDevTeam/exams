function maxSubarraySum(array) {
    let maxSoFar = 0;
    let maxEndingHere = 0;
  
    for (let i = 0; i < array.length; i++) {
        //compare the value of the current index with the sum of previous index
        //take the larger one
        maxEndingHere = Math.max(maxEndingHere + array[i], array[i]);

        //holding the value that has most sum value in the array
        maxSoFar = Math.max(maxSoFar, maxEndingHere);
    }
  
    return maxSoFar;
  }

const array = [1, 2, -3, 4, -1, 2, 1, -5, 4];

const maxSum = maxSubarraySum(array);

console.log(maxSum);
