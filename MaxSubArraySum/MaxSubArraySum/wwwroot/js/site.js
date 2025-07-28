function maxSubArraySum(arr) {
    if (arr.length === 0) return 0;

    let maxSoFar = arr[0];
    let currentMax = arr[0];

    for (let i = 1; i < arr.length; i++) {
        currentMax = Math.max(arr[i], currentMax + arr[i]);
        maxSoFar = Math.max(maxSoFar, currentMax);
    }

    console.log("Maximum Subarray Sum:", maxSoFar);
    alert("Maximum Subarray Sum: " + maxSoFar);
}

const nums = [-2, 1, -3, 4, -1, 2, 1, -5, 4];
maxSubArraySum(nums);

