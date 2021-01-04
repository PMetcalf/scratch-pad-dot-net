% Opening and Working with CSV Files

% Input variables
input_file_name = "anscombes-quartet.csv";
input_file_directory = "D:/Developer Area/scratch-pad/Datasets/";
delimiter = ",";
skip_header = 1;
column_x = 3;
column_y = 4;

% Strings concatenated using matrix format
file_string = [input_file_directory input_file_name];

% Load dataset
data = dlmread(file_string, delimiter, skip_header, 0);

% Slice out x and y
x = data(:, column_x);
y = data(:, column_y);

% Fit the data
poly = polyfit(x, y, 1);

slope = poly(1)
intercept = poly(2)