NativeCppLibrary.h:

#ifdef NATIVECPPLIBRARY_EXPORTS
#define NATIVECPPLIBRARY_API __declspec(dllexport)
#else
#define NATIVECPPLIBRARY_API __declspec(dllimport)# endif
// This class is exported from the dll
class NATIVECPPLIBRARY_API CNativeCppLibrary {
        public: CNativeCppLibrary(void);
// TODO: add your methods here.
};
extern NATIVECPPLIBRARY_API int nNativeCppLibrary;
NATIVECPPLIBRARY_API int fnNativeCppLibrary(void);

// Single line function declarations
extern “C” NATIVECPPLIBRARY_API int displayNumber();
extern “C” NATIVECPPLIBRARY_API int getRandom();
extern “C” NATIVECPPLIBRARY_API int displaySum();
// Block declarations
extern “C” {
NATIVECPPLIBRARY_API int displayNumber();
NATIVECPPLIBRARY_API int getRandom();
NATIVECPPLIBRARY_API int displaySum();
}

//#ifndef DLL_1_2_LIBRARY_H
//#define DLL_1_2_LIBRARY_H
//
//void hello();
//
//#endif //DLL_1_2_LIBRARY_H