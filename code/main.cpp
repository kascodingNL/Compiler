#include <iostream>

extern "C" int num(int, int);

int main() {
    std::cout << "Output of num(5, 3): " << num(5, 3) << std::endl;
    return 0;
}