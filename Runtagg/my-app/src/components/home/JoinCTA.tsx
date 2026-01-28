import SectionWrapper from "./SectionWrapper";

export default function JoinCTA() {
  return (
    <SectionWrapper
      id="join"
      className="relative overflow-hidden rounded-[32px] border border-white/15 bg-gradient-to-r from-[#020617] via-[#020617] to-[#020617]"
    >
      <div className="pointer-events-none absolute inset-0 bg-[radial-gradient(circle_at_0%_0%,rgba(124,58,237,0.45),transparent_55%),radial-gradient(circle_at_100%_100%,rgba(56,189,248,0.45),transparent_55%)] opacity-90" />

      <div className="relative flex flex-col items-start gap-6 px-6 py-10 text-slate-50 sm:px-10 md:flex-row md:items-center md:justify-between">
        <div className="space-y-4">
          <p className="text-[11px] font-semibold uppercase tracking-[0.3em] text-slate-200/80">
            Join the Studio
          </p>
          <h2 className="text-2xl font-semibold uppercase tracking-[0.2em] sm:text-3xl">
            Wanna build something with us?
          </h2>
          <p className="max-w-xl text-sm text-slate-100/90">
            We’re always looking for developers, artists, designers and curious
            minds. Join a crew, ship a project, learn together.
          </p>
        </div>

        <div className="flex flex-col items-start gap-3 md:items-end">
          <div className="flex flex-wrap gap-3">
            <button className="group relative inline-flex items-center justify-center overflow-hidden rounded-full px-6 py-2.5 text-xs font-semibold uppercase tracking-[0.25em] text-white">
              <span className="absolute inset-0 accent-gradient opacity-90 transition duration-300 group-hover:opacity-100" />
              <span className="absolute inset-0 bg-white/10 opacity-0 blur-xl transition duration-300 group-hover:opacity-70" />
              <span className="relative">Apply to Join a Crew</span>
            </button>
            <button className="inline-flex items-center justify-center rounded-full border border-white/40 bg-white/5 px-6 py-2.5 text-xs font-semibold uppercase tracking-[0.25em] text-slate-50/90 transition hover:bg-white/10">
              Pitch a Project
            </button>
          </div>
          <p className="max-w-xs text-[11px] text-slate-200/80">
            You can start with just your GitHub, itch.io, Behance or portfolio
            link.
          </p>
        </div>
      </div>
    </SectionWrapper>
  );
}

