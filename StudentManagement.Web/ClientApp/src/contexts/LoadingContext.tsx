import {
    createContext,
    CSSProperties,
    ReactNode,
    useState
} from 'react';

type LoadingContextProviderProps = {
    children: ReactNode;
}

const LoadingContext = createContext({
    loadingCount: 0,
    showLoading: () => {},
    hideLoading: () => {}
});

const LoadingContextProvider = function LoadingContextProvider({children} : LoadingContextProviderProps) {

      const showLoading = () => {
        toggleLoading(prevState => {
          return {
            ...prevState,
            loadingCount: prevState.loadingCount + 1
          }
        })
      }
    
      const hideLoading = () => {
        toggleLoading(prevState => {
          return {
            ...prevState,
            loadingCount:
              prevState.loadingCount > 0 ? prevState.loadingCount - 1 : 0
          }
        })
      }
    
      const loadingState = {
        loadingCount: 0,
        showLoading,
        hideLoading
      }
    
      const [loading, toggleLoading] = useState(loadingState)
   

    return (
        <LoadingContext.Provider value={loading}>
            {children}
        </LoadingContext.Provider>
    );

}

export {LoadingContext, LoadingContextProvider}