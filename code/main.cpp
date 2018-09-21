#include <iostream>

extern "C" int num(int);

int main() {
    std::cout << "Output of num(1): " << num(1) << std::endl;
    return 0;
}