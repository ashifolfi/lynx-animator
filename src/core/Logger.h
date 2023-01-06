#pragma once

#include <string_view>
#include <functional>
#include <unordered_map>
#include <fmt/core.h>
#include <utility/UUIDGenerator.h>

namespace lynxanim {

enum class LogType {
    LOG_INFO,           // white
    LOG_INFO_IMPORTANT, // green
    LOG_OUTPUT,         // blue
    LOG_WARNING,        // yellow
    LOG_ERROR           // red
};

class Logger {
    friend class LogChannel;
    using loggingCallback = std::function<void(LogType,std::string_view,std::string_view)>;
public:
    Logger() = delete;
    static uuids::uuid addCallback(const loggingCallback& callback);
    static void runLogHooks(LogType type, std::string_view source, std::string_view message);
    static void removeCallback(const uuids::uuid& id);
private:
    static void log(LogType type, std::string_view source, std::string_view message);

public:
    static inline constexpr std::string_view INFO_PREFIX = "[*]";
    static inline constexpr std::string_view INFO_IMPORTANT_PREFIX = "[!]";
    static inline constexpr std::string_view OUTPUT_PREFIX = "[O]";
    static inline constexpr std::string_view WARNING_PREFIX = "[W]";
    static inline constexpr std::string_view ERROR_PREFIX = "[E]";
private:
    static inline std::unordered_map<uuids::uuid, loggingCallback> callbacks;
};

class LogChannel {
    class LogChannelLogger {
    public:
        constexpr LogChannelLogger(LogType type_, std::string_view source_) : type(type_), source(source_) {}
        inline const LogChannelLogger& operator<<(std::string_view message) const {
            Logger::log(this->type, this->source, message);
            return *this;
        }
    private:
        LogType type;
        std::string_view source;
    };
public:
    /// Assumes the std::string_view passed will never lose sight of the data it is viewing
    constexpr explicit LogChannel(std::string_view name_)
            : name(name_)
            , infoLogger(LogType::LOG_INFO, name_)
            , infoImportantLogger(LogType::LOG_INFO_IMPORTANT, name_)
            , outputLogger(LogType::LOG_OUTPUT, name_)
            , warningLogger(LogType::LOG_WARNING, name_)
            , errorLogger(LogType::LOG_ERROR, name_) {}

    [[nodiscard]] constexpr std::string_view getName() const {
        return this->name;
    }

    [[nodiscard]] inline constexpr const LogChannelLogger& info() const {
        return this->infoLogger;
    }
    [[nodiscard]] inline constexpr const LogChannelLogger& infoImportant() const {
        return this->infoImportantLogger;
    }
    [[nodiscard]] inline constexpr const LogChannelLogger& output() const {
        return this->outputLogger;
    }
    [[nodiscard]] inline constexpr const LogChannelLogger& warning() const {
        return this->warningLogger;
    }
    [[nodiscard]] inline constexpr const LogChannelLogger& error() const {
        return this->errorLogger;
    }

    template<typename... FmtArgs>
    inline void info(std::string_view message, FmtArgs... fmtArgs) const {
        if constexpr (sizeof...(fmtArgs) == 0) {
            this->info() << message;
        } else {
            this->info() << fmt::format(fmt::runtime(message), fmtArgs...);
        }
    }
    template<typename... FmtArgs>
    inline void infoImportant(std::string_view message, FmtArgs... fmtArgs) const {
        if constexpr (sizeof...(fmtArgs) == 0) {
            this->infoImportant() << message;
        } else {
            this->infoImportant() << fmt::format(fmt::runtime(message), fmtArgs...);
        }
    }
    template<typename... FmtArgs>
    inline void output(std::string_view message, FmtArgs... fmtArgs) const {
        if constexpr (sizeof...(fmtArgs) == 0) {
            this->output() << message;
        } else {
            this->output() << fmt::format(fmt::runtime(message), fmtArgs...);
        }
    }
    template<typename... FmtArgs>
    inline void warning(std::string_view message, FmtArgs... fmtArgs) const {
        if constexpr (sizeof...(fmtArgs) == 0) {
            this->warning() << message;
        } else {
            this->warning() << fmt::format(fmt::runtime(message), fmtArgs...);
        }
    }
    template<typename... FmtArgs>
    inline void error(std::string_view message, FmtArgs... fmtArgs) const {
        if constexpr (sizeof...(fmtArgs) == 0) {
            this->error() << message;
        } else {
            this->error() << fmt::format(fmt::runtime(message), fmtArgs...);
        }
    }
private:
    std::string_view name;
    LogChannelLogger infoLogger;
    LogChannelLogger infoImportantLogger;
    LogChannelLogger outputLogger;
    LogChannelLogger warningLogger;
    LogChannelLogger errorLogger;
};

} // namespace lynxanim

#define LYNX_CREATE_LOG(name) lynxanim::LogChannel LOG_##name{#name}
#define LYNX_GET_LOG(name) extern lynxanim::LogChannel LOG_##name
