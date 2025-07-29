maxSubarraySum([-2, 1, -3, 4, -1, 2, 1, -5, 4]) // 输出 6
// 因为最大子数组是 [4, -1, 2, 1]

function maxSubarraySum(arr) {
    let maxSum = arr[0];
    let currentSum = arr[0];

    for (let i = 1; i < arr.length; i++) {
        currentSum = Math.max(arr[i], currentSum + arr[i]);
        maxSum = Math.max(maxSum, currentSum);
    }

    return maxSum;
}

// 测试
console.log(maxSubarraySum([-2, 1, -3, 4, -1, 2, 1, -5, 4])); // 输出 6
